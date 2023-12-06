import numpy as np

lines = open("./input.txt").readlines()

def method(times, distances):
    ranges = 1
    for i in range(len(times)):
        for time in range(times[i]):
            if time * (times[i] - time) > distances[i]:
                ranges *= ((times[i] - time) - time) + 1
                break
    return ranges

t, d = [np.int64(line) for line in lines[0].strip().split(" ")[1:] if line != ""], [np.int64(line) for line in lines[1].strip().split(" ")[1:] if line != ""]

print("Part one", method(t, d))
print("Part two", method([np.int64("".join([str(n) for n in t]))], [np.int64("".join([str(n) for n in d]))]))
