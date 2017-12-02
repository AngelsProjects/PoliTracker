using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;
using Android.Widget;
using Android.Locations;

namespace PoliTracker
{
    [Activity(Theme = "@style/Theme.MyTheme", Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        private GoogleMap GMap;
        Spinner spinner;
        Location _currentLocation;

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

            GMap = googleMap;
         //   GMap.SetLocationSource(followMeLocationSource);

            // Set default zoom
            GMap.MoveCamera(CameraUpdateFactory.ZoomTo(15f));

            // LatLng latlng = new LatLng(32.668849781762106, -115.40940821170807);
            //   CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            // GMap.MoveCamera(camera);
            // MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Chennai");
            //  GMap.AddMarker(options);
            GMap.MyLocationEnabled = true;
            GMap.UiSettings.MyLocationButtonEnabled = true;
            MarkerOptions Estacion1 = new MarkerOptions();
            Estacion1.SetPosition(new LatLng(32.668531, -115.40853300000003));
            Estacion1.SetTitle("Estacion Policia Pimsa 1");
            Estacion1.SetSnippet("Numero telefonico: 01 686 558 1600");
            Estacion1.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.poli_opt));
            MarkerOptions Estacion2 = new MarkerOptions();
            Estacion2.SetPosition(new LatLng(32.65649090000001, -115.46213390000003));
            Estacion2.SetTitle("Estación de Policía Industrial");
            Estacion2.SetSnippet("Numero telefonico: 01 686 554 7958");
            Estacion2.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.poli_opt));
            MarkerOptions Estacion3 = new MarkerOptions();
            Estacion3.SetPosition(new LatLng(32.64598600000001, -115.44252899999998));
            Estacion3.SetTitle("ESTACIÓN DE POLICÍA PRIMERO DE DICIEMBRE");
            Estacion3.SetSnippet("Numero telefonico: 01 686 564 9130");
            Estacion3.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.poli_opt));
            GMap.AddMarker(Estacion1);
            GMap.AddMarker(Estacion2);
            GMap.AddMarker(Estacion3);
        }
    }
}

