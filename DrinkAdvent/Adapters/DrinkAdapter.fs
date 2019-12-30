namespace DrinkAdvent.Adapters

open System
open Android.App
open Android.Content
open Android.Views
open Android.Widget
open DrinkAdvent.Models

type AppResources = DrinkAdvent.Resource

type DrinkAdapter(a: Activity, list: List<Drink>)= class
    inherit BaseAdapter<Drink>()

    override this.Item with get(position) = 
        list.[position]
    override this.Count with get() = 
        list.Length
    override this.GetItemId(position) = 
        int64 position
    override this.GetView(position: int, view: Android.Views.View, parent: Android.Views.ViewGroup): View = begin
        let item = list.Item(position)
        let view = a.LayoutInflater.Inflate(AppResources.Layout.drink_list_item, null)

        (*if (view <> null) then
                        view
                    else
                        a.LayoutInflater.Inflate(AppResources.Layout.DrinkListItem, parent, false)*)

        // Find Elements
        let txtDrinkName = view.FindViewById<TextView>(AppResources.Id.txtDrinkName)
        let txtIngredient1 = view.FindViewById<TextView>(AppResources.Id.txtIngredient1)
        let imgDrink = view.FindViewById<ImageView>(AppResources.Id.imgDrink)
        // Asign items Value
        txtDrinkName.Text <- string item.StrDrink
        txtIngredient1.Text <- item.Ingredient1
        let logoUrl = "https://raw.github.com/fsharp/FSharp.Data/master/misc/logo.png"
        match FSharp.Data.Http.Request(item.ImgDrink).Body with
        | FSharp.Data.HttpResponseBody.Binary bytes ->
            let imgMap = Android.Graphics.BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length)
            imgDrink.SetImageBitmap imgMap
        view
    end
end
