using AcquistionTool.Base;
using AcquistionTool.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AcquistionTool.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        //  private readonly BaseSystem _baseSystem;

        private BaseViewModels _monitorStatus = new BaseViewModels();
        private BaseViewModels _openFile = new BaseViewModels();
        private BaseViewModels _imageList = new BaseViewModels();

        private MonitorStatusViewModel _monitorStatusViewModel = BaseVariable.MonitorStatusViewModel;
        private OpenFileViewModel _openFileViewModel = BaseVariable.OpenFileViewModel;
        public MainViewModels()
        {
            _monitorStatus = _monitorStatusViewModel;
            _openFile = _openFileViewModel;
            ImageSourceCollection = new ObservableCollection<ClassImage>();
            BaseVariable.ListFileNameChanged += BaseVariable_ListFileNameChanged;
            GetImageInList = new RelayCommand<MainViewModels>(p => { ShowImageInList(); }, p => true);
        }

        

        public class ClassImage
        {
            public ClassImage(BitmapImage imageSource)
            {
                IndexImageSource = imageSource;
            }

            public BitmapImage IndexImageSource { get; set; }

        }
        private void BaseVariable_ListFileNameChanged(object? sender, List<BitmapImage> e)
        {
            if(e == null || e.Count == 0) return;
            for (int i = 0; i < e.Count; i++)
            {
                    ImageSourceCollection.Add( new ClassImage(e[i]));
            }
            CurrentImageSource = e[0];
        }

        private void ShowImageInList()
        {
           
        }

        private ObservableCollection<ClassImage> _imageSourceCollection;

        public ObservableCollection<ClassImage> ImageSourceCollection
        {
            get { return _imageSourceCollection; }
            set
            {
                _imageSourceCollection = value;
                OnPropertyChanged(); 
            }
        }

        private ImageSource _currentImageSource;

        public ImageSource CurrentImageSource
        {
            get { return _currentImageSource; }
            set
            {
                _currentImageSource = value;
                OnPropertyChanged();
            }
        }
        
        public BaseViewModels MonitorStatus
        {
            get { return _monitorStatus; }
            set
            {
                _monitorStatus = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModels OpenFile
        {
            get { return _openFile; }
            set
            {
                _openFile = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModels ImageList
        {
            get { return _imageList; }
            set
            {
                _imageList = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetImageInList { get; set; }
    }
}
