namespace DrinkAdvent.Models

open System
open FSharp.Data

type APIResult = JsonProvider<"https://www.thecocktaildb.com/api/json/v1/1/search.php?s=Margarita">

type DrinkAPI()=
    class
    let baseURL = "https://www.thecocktaildb.com/api/json/v1/1"

    member self.GetDrink (name:string) =
        let api = sprintf "%s/search.php?s=%s" baseURL name
        APIResult.Load(api)
        
    end