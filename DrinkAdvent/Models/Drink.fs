namespace DrinkAdvent.Models

type Drink()=
    class
    let mutable idDrink: int = 0
    let mutable strDrink = ""
    let mutable imgDrink = ""
    let mutable ingredient1 = ""
    member this.IdDrink
        with get() = idDrink
        and set(value) = idDrink <- value
    member this.StrDrink
        with get() = strDrink
        and set(value) = strDrink <- value
    member this.ImgDrink
        with get() = imgDrink
        and set(value) = imgDrink <- value
    member this.Ingredient1
        with get() = ingredient1
        and set(value) = ingredient1 <- value
    end
