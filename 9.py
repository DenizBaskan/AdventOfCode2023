def all_same(arr, v):
    for a in arr:
        if a != v:
            return False
    return True

p1_sum = 0
p2_sum = 0

for line in open("input.txt").readlines():
    arr = [[int(v) for v in line.split(" ")]] # 2D array

    while not all_same(arr[len(arr) - 1], 0):
        differences = []
        buf = arr[len(arr) - 1]
        
        for i, v in enumerate(buf):
            if i != 0:
                differences.append(v - buf[i - 1])

        arr.append(differences)

    end_diff, start_diff = 0, 0
    for i, v in enumerate(reversed(arr)):
        end_diff = (v[len(v) - 1] - v[len(v) - 2]) + end_diff
        if all_same(v, v[0]):
            start_diff = v[0]
        else:
            start_diff = v[0] - start_diff
    
    p1_sum += (arr[0][len(arr[0]) - 1] + end_diff)
    p2_sum += start_diff
    
print("Part one", p1_sum)
print("Part two", p2_sum)
