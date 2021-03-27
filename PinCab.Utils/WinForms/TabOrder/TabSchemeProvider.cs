using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Utils.WinForms.TabOrder
{
	/// <summary>
	/// Wrap the TabOrderManager class and supply extendee controls with a custom tab scheme.
	/// </summary>
	[ProvideProperty("TabScheme", typeof(Control))]
	[Description("Wrap the TabOrderManager class and supply extendee controls with a custom tab scheme")]
	[ToolboxBitmap(typeof(TabSchemeProvider), "TabSchemeProvider")]
	public partial class TabSchemeProvider : Component, IExtenderProvider
	{

		#region MEMBER VARIABLES

		/// <summary>
		/// Hashtable to store the controls that use our extender property.
		/// </summary>
		private Hashtable extendees = new Hashtable();

		/// <summary>
		/// The form we're hosted on, which will be calculated by watching the extendees entering the control hierarchy.
		/// </summary>
		private Form topLevelForm = null;

		#endregion

		#region PUBLIC PROPERTIES
		#endregion

		public TabSchemeProvider()
		{
			InitializeComponent();
		}

		public TabSchemeProvider(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		/// <summary>
		/// Get whether or not we're managing a given control.
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		[DefaultValue(TabOrderManager.TabScheme.None)]
		public TabOrderManager.TabScheme GetTabScheme(Control c)
		{
			if (!extendees.Contains(c))
			{
				return TabOrderManager.TabScheme.None;
			}

			return (TabOrderManager.TabScheme)extendees[c];
		}

		/// <summary>
		/// Hook up to the form load event and indicate that we've done so.
		/// </summary>
		private void HookFormLoad()
		{
			if (topLevelForm != null)
			{
				topLevelForm.Load += new EventHandler(TopLevelForm_Load);
			}
		}

		/// <summary>
		/// Unhook from the form load event and indicate that we need to do so again before applying tab schemes.
		/// </summary>
		private void UnhookFormLoad()
		{
			if (topLevelForm != null)
			{
				topLevelForm.Load -= new EventHandler(TopLevelForm_Load);
				topLevelForm = null;
			}
		}

		/// <summary>
		/// Hook up to all of the parent changed events for this control and its ancestors so that we are informed
		/// if and when they are added to the top-level form (whose load event we need).
		/// It's not adequate to look at just the control, because it may have been added to its parent, but the parent
		/// may not be descendent of the form -yet-.
		/// </summary>
		/// <param name="c"></param>
		private void HookParentChangedEvents(Control c)
		{
			while (c != null)
			{
				c.ParentChanged += new EventHandler(Extendee_ParentChanged);
				c = c.Parent;
			}
		}

		/// <summary>
		/// Set the tab scheme to use on a given control
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public void SetTabScheme(Control c, TabOrderManager.TabScheme val)
		{
			if (val != TabOrderManager.TabScheme.None)
			{
				extendees[c] = val;

				if (topLevelForm == null)
				{
					if (c.TopLevelControl != null)
					{
						// We're in luck.
						// This is the form, or this control knows about it, so take the opportunity to grab it and wire up to its Load event.
						topLevelForm = c.TopLevelControl as Form;
						HookFormLoad();
					}
					else
					{
						// Set up to wait around until this control or one of its ancestors is added to the form's control hierarchy.
						HookParentChangedEvents(c);
					}
				}
			}
			else if (extendees.Contains(c))
			{
				extendees.Remove(c);

				// If we no longer have any extendees, we don't need to be wired up to the form load event.
				if (extendees.Count == 0)
				{
					UnhookFormLoad();
				}
			}
		}

		#region IExtenderProvider Members

		public bool CanExtend(object extendee)
		{
			return (extendee is Form || extendee is Panel || extendee is GroupBox || extendee is UserControl);
		}

		#endregion

		private void TopLevelForm_Load(object sender, EventArgs e)
		{
			Form f = sender as Form;

			Debug.Assert(f != null, "We should never wire up to anything that's not a form.");

			TabOrderManager tom = new TabOrderManager(f);

			// Add an override for everything with a tab scheme set EXCEPT for the form, which
			// serves as the root of the whole process.
			TabOrderManager.TabScheme formScheme = TabOrderManager.TabScheme.None;
			IDictionaryEnumerator extendeeEnumerator = extendees.GetEnumerator();
			while (extendeeEnumerator.MoveNext())
			{
				Control c = (Control)extendeeEnumerator.Key;
				TabOrderManager.TabScheme scheme = (TabOrderManager.TabScheme)extendeeEnumerator.Value;
				if (c == f)
				{
					formScheme = scheme;
				}
				else
				{
					tom.SetSchemeForControl(c, scheme);
				}
			}

			tom.SetTabOrder(formScheme);
		}

		/// <summary>
		/// We track when each extendee's parent is changed, and also when their parents are changed, until
		/// SOMEBODY finally changes their parent to the form, at which point we can hook the load to apply
		/// the tab schemes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Extendee_ParentChanged(object sender, EventArgs e)
		{
			if (topLevelForm != null)
			{
				// We've already found the form and attached a load event handler, so there's nothing left to do.
				return;
			}

			Control c = sender as Control;
			if (c.TopLevelControl != null && c.TopLevelControl is Form)
			{
				// We found the form, so we're done.
				topLevelForm = c.TopLevelControl as Form;
				HookFormLoad();
			}
		}
	}
}
