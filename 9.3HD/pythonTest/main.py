import timeit


class Shape:
    def area(self):
        pass


class Rectangle(Shape):
    def __init__(self, length, width):
        self.length = length
        self.width = width

    def area(self):
        return self.length * self.width


def benchmark():
    rectangles = [Rectangle(5, 10) for _ in range(1000000)]
    total_area = sum(rectangle.area() for rectangle in rectangles)


# Measure the execution time for the benchmark function
execution_time = timeit.timeit(benchmark, number=100)  # Run the benchmark 100 times
average_time = execution_time / 100

print(f"Average Execution Time for 3x Intensive Rectangle Area (Python): {average_time:.15f} seconds")
