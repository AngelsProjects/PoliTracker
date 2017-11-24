using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;

namespace PoliTracker
{
    [Activity(Theme = "@style/Theme.MyTheme", Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        private GoogleMap GMap;
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
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {


          //  var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            GMap = googleMap;
            LatLng latlng = new LatLng(Convert.ToDouble(13.0291), Convert.ToDouble(80.2083));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            GMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Chennai");
            GMap.AddMarker(options);
            //  GMap.setMyLocationEnabled(true);\
            GMap.MyLocationEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;
        }
    }
}

