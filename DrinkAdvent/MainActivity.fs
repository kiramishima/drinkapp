namespace DrinkAdvent

open System

open Android.App
open Android.Support.Design.Widget
open Android.Support.V7.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

type Resources = DrinkAdvent.Resource

[<Activity (Label = "DrinkAdvent", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/DemoTheme")>]
type MainActivity () =
    inherit AppCompatActivity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)

        // Codigo en la grabacion
        let input = this.FindViewById<TextInputEditText>(Resources.Id.txtSearch)
        input.EditorAction.Add (fun args ->
            args.Handled <- false
            if  args.ActionId = InputMethods.ImeAction.Search then
                args.Handled <- true
                let intent = new Intent(this, typedefof<ActivityResult>)
                intent.PutExtra("DRINK_NAME", input.Text) |> ignore
                this.StartActivity(intent)
        )

