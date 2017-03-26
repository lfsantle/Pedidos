using System;

using Xamarin.Forms;

using MasterDetailPageNavigation.Models;

namespace MasterDetailPageNavigation
{
	public class PedidoNovoPage : ContentPage
	{
		public PedidoNovoPage()
		{
			/*
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
			*/

			Content = new TableView
			{
				Root = new TableRoot("Table Title")
				{
					new TableSection("Section 1 Title")
					{
						new TextCell
						{
							Text = "TextCell Text",
							Detail = "TextCell Detail"
						},
						new ImageCell
						{
							Text = "ImageCell Text",
							Detail = "ImageCell Detail",
							ImageSource = "http://xamarin.com/images/index/ide-xamarin-studio.png"
						},
						new EntryCell
						{
							Label = "EntryCell:",
							Placeholder = "default keyboard",
							Keyboard = Keyboard.Default
						}
					},
					new TableSection("Section 2 Title")
					{
						new EntryCell
						{
							Label = "Another EntryCell:",
							Placeholder = "phone keyboard",
							Keyboard = Keyboard.Telephone
						},
						new SwitchCell
						{
							Text = "SwitchCell:"
						},
						new ViewCell
						{
							View = new StackLayout
							{
								Orientation = StackOrientation.Horizontal,
								Children =
								{
									new Label
									{
										Text = "Custom Slider View:"
									},
									new Slider
									{
									}
								}
							}
						}
					}
				}
			};
		}
	}
}

