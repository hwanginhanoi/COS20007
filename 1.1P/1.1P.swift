func hello(name: String) -> String {
   return "Hello \(name)!"
}
print(hello(name: "Hoang"))

func average(_ numbers: [Int]) -> Double {
    var sum = 0
    for number in numbers {
        sum += number
    }
    
    let count = numbers.count
    if count > 0 {
        return Double(sum) / Double(count)
    } else {
        return 0
    }
}

let numbers = [2, 4, 6, 8, 10]
let result = average(numbers)
print("The average is: \(result)")
if result >= 10 {
    print("Double digits")
} else {
    print("Single digits")
}



