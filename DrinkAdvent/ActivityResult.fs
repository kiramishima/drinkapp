namespace DrinkAdvent

open System
open System.Linq
open System.Text

open Android.App
open Android.Support.Design.Widget
open Android.Support.V7.App
open Android.Content
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open DrinkAdvent.Models
open DrinkAdvent.Adapters

type Resources2 = DrinkAdvent.Resource

[<Activity (Label = "ActivityResult", Theme = "@style/DemoTheme")>]
type ActivityResult () =
  inherit AppCompatActivity()
  let mutable drinkName: string = ""
  let mutable lvDrink: ListView = null
  let mutable adapter = new DrinkAdapter(null, List<Drink>.Empty)
  let api = new DrinkAPI()


  override this.OnCreate(bundle) =
    base.OnCreate (bundle)
    // Create your application here
    this.SetContentView (Resources2.Layout.Result)

    drinkName <- this.Intent.GetStringExtra("DRINK_NAME")
    // Listview
    lvDrink <- this.FindViewById<ListView>(Resources2.Id.DrinkList)
    lvDrink.Adapter <- adapter
    // API
    let r = api.GetDrink drinkName
    let result = [
        for i in r.Drinks do
            let a = new Drink()
            a.IdDrink <- i.IdDrink
            a.StrDrink <- i.StrDrink
            a.ImgDrink <- i.StrDrinkThumb
            a.Ingredient1 <- i.StrIngredient1
            a
    ]
    adapter <- new DrinkAdapter(this, result)
    lvDrink.Adapter <- adapter
