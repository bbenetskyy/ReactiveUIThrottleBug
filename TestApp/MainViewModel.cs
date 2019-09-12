using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using static System.String;

namespace TestApp
{
    public class MainViewModel : ReactiveObject
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                this.RaisePropertyChanged(nameof(SearchText));
            }
        }

        private ObservableCollection<string> _collection;

        public ObservableCollection<string> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                this.RaisePropertyChanged(nameof(Collection));
            }
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                this.RaisePropertyChanged(nameof(IsSearching));
            }
        }

        public ReactiveCommand<Unit, Unit> ClearCommand { get; }

        public MainViewModel()
        {
            Collection = new ObservableCollection<string>();

            var observable = this.WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .ObserveOn(RxApp.MainThreadScheduler)
                .DistinctUntilChanged();

            observable.Where(IsNullOrEmpty)
                .Subscribe(_ =>
                {
                    _cts.Cancel();
                    Collection.Clear();
                    IsSearching = false;
                });

            observable.Where(x => !IsNullOrEmpty(x))
                .Do(_ =>
                {
                    _cts.Cancel();
                    _cts = new CancellationTokenSource();
                    Collection.Clear();
                    IsSearching = true;
                })
                .Subscribe(async _ => await OnSearch(_cts.Token));

            ClearCommand = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                SearchText = Empty;
                _cts.Cancel();
                Collection.Clear();
                IsSearching = false;
                return Unit.Default;
            });
            ClearCommand.ObserveOn(RxApp.MainThreadScheduler).Subscribe();
        }

        private async Task OnSearch(CancellationToken token)
        {
            for (int i = 1; i <= 40; i++)
            {
                if (token.IsCancellationRequested)
                    break;
                await Task.Delay(TimeSpan.FromMilliseconds(500));

                if (token.IsCancellationRequested)
                    break;
                Collection.AddRange(new List<string>
                {
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                    DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),DateTime.Now.Millisecond.ToString(),
                });

                if (i == 40)
                    IsSearching = false;
            }
        }
    }
}
