using System;
using System.Collections.Generic;
using Messier16.VstsClient.Objects;
using Xamarin.Forms;

namespace WhoBrokeIt.UI.Controls
{
    public partial class BuildDefinition : ContentView
    {
        public event EventHandler<BasicBuildDefinition> BuildTapped;

        public BuildDefinition()
        {
            InitializeComponent();
#pragma warning disable CS0618 // Type or member is obsolete
            var gestureRecognizer = new TapGestureRecognizer((sender) =>
            {
                BuildTapped?.Invoke(this, BindingContext as BasicBuildDefinition);
            });
#pragma warning restore CS0618 // Type or member is obsolete

            this.Content.GestureRecognizers.Add(gestureRecognizer);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var build = BindingContext as BasicBuildDefinition;
            if (build != null)
            {
                BuildNameLabel.Text = build.Name;
                RequestorNameLabel.Text = build.AuthoredBy.DisplayName;
            }
        }
    }
}
