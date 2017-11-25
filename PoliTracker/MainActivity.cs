using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;
using Android.Widget;

namespace PoliTracker
{
    [Activity(Theme = "@style/Theme.MyTheme", Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        private GoogleMap GMap;
           Spinner spinner;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set your main view here
            SetContentView(Resource.Layout.main);
            SetUpMap();
            Log.Debug(TAG, "MainActivity is loaded.");
        }
        private void SetUpMap()
        {
            if (GMap == null)
            {
                spinner = FindViewById<Spinner>(Resource.Id.spinner);
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
                spinner.ItemSelected += Spinner_ItemSelected;
            }
        }
        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    GMap.MapType = GoogleMap.MapTypeHybrid;
                    break;
                case 1:
                    GMap.MapType = GoogleMap.MapTypeNone;
                    break;
                case 2:
                    GMap.MapType = GoogleMap.MapTypeNormal;
                    break;
                case 3:
                    GMap.MapType = GoogleMap.MapTypeSatellite;
                    break;
                case 4:
                    GMap.MapType = GoogleMap.MapTypeTerrain;
                    break;
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //GMap.MapType = MapType.Standard;
            //int typesWidth = 260, typesHeight = 30, distanceFromBottom = 60;
            //mapTypes = new UISegmentedControl(new CGRect((View.Bounds.Width - typesWidth) / 2, View.Bounds.Height - distanceFromBottom, typesWidth, typesHeight));
            //mapTypes.BackgroundColor = UIColor.White;
            //mapTypes.Layer.CornerRadius = 5;
            //mapTypes.ClipsToBounds = true;
            //mapTypes.InsertSegment("Road", 0, false);
            //mapTypes.InsertSegment("Satellite", 1, false);
            //mapTypes.InsertSegment("Hybrid", 2, false);
            //mapTypes.SelectedSegment = 0; // Road is the default
            //mapTypes.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
            //mapTypes.ValueChanged += (s, e) => {
            //    switch (mapTypes.SelectedSegment)
            //    {
            //        case 0:
            //            mapView.MapType = MKMapType.Standard;
            //            break;
            //        case 1:
            //            mapView.MapType = MKMapType.Satellite;
            //            break;
            //        case 2:
            //            mapView.MapType = MKMapType.Hybrid;
            //            break;
            //    }
            //};


            //  var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            GMap = googleMap;
            LatLng latlng = new LatLng(80, 80);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            GMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Chennai");
            GMap.AddMarker(options);
            GMap.MyLocationEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;

        }
    }
}

