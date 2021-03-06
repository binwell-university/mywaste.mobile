using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteMobile.UI.Pages.Request.DataObjects;
using MvvmHelpers;
using Xamarin.Forms;
using Plugin.Messaging;
using Xamarin.Essentials;

namespace MyWasteMobile.BL.ViewModels.Request

{
	public class RequestHistoryViewModel : BaseViewModel
	{

		ObservableRangeCollection<object> _itemsSource = new ObservableRangeCollection<object>();

		ICommand _itemSelectedCommand;
		private string hotline = "+89993543454";

		public ICommand MakeCall => MakeCommand(OnCallCommand);



		public ICommand ItemSelectedCommand => _itemSelectedCommand ??
											   (_itemSelectedCommand = new Command(async (o) =>
												   await ItemSelectedCommandAsync(o)));

		async void OnCallCommand()
		{
			var phoneDialer = CrossMessaging.Current.PhoneDialer;
			var answer = false;

			if (phoneDialer.CanMakePhoneCall)
				answer = await ShowQuestion("Набрать номер горячей линии?", hotline, "Да", "Нет");
			if (answer)
					phoneDialer.MakePhoneCall(hotline);
		}

		public ObservableRangeCollection<object> ItemsSource {
			get => _itemsSource;
			set {
				_itemsSource = value;
				OnPropertyChanged();
			}
		}

		public RequestHistoryViewModel() {
			GenerateSource();
		}


		async Task ItemSelectedCommandAsync(object obj) {
			if (obj is RequestObject request)
				await ShowAlert(request.Address, request.Waste + " " + request.Status, "OK");
		}

		void GenerateSource() {
			var size = Device.Info.ScaledScreenSize;
			var r = new Random(DateTime.Now.Millisecond);


			var items = new List<object>
			{
				new CategoryObject {Name = "Активные заказы"},

				new RequestObject()
				{
					Address = "г. Воронеж, ул. Соврасова, д. 12, кв. 4.",
					Waste = "Пластик, 10 - 20 кг.",
					Status = "Статус: вывоз запланирован на 19 Янв 2019, с 10:00 до 18:00, водитель позвонит в день вывоза"
				},

				new RequestObject()
				{
					Address = "г. Воронеж, ул. Соврасова, д. 12, кв. 4.",
					Waste = "Пластик, 10 - 20 кг.",
					Status = "Статус: вывоз запланирован на 19 Янв 2019, с 10:00 до 18:00, водитель позвонит в день вывоза"
				},
				new RequestObject()
				{
					Address = "г. Воронеж, ул. Соврасова, д. 12, кв. 4.",
					Waste = "Пластик, 10 - 20 кг.",
					Status = "Статус: вывоз запланирован на 19 Янв 2019, с 10:00 до 18:00, водитель позвонит в день вывоза"
				},
				new RequestObject()
				{
					Address = "г. Воронеж, ул. Соврасова, д. 12, кв. 4.",
					Waste = "Пластик, 10 - 20 кг.",
					Status = "Статус: вывоз запланирован на 19 Янв 2019, с 10:00 до 18:00, водитель позвонит в день вывоза"
				},

				new CategoryObject {Name = "Выполенные заказы"},
				new RequestObject()
				{
					Address = "г. Воронеж, ул. Соврасова, д. 12, кв. 4.",
					Waste = "Пластик, 12 кг.",
					Status = "Статус: выполнен 10 Дек 2018, 13:48"
				},

			};

			;
			ItemsSource.AddRange(items);
		}
	}
}
