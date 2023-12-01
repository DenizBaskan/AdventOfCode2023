lines = [line.strip() for line in open("input.txt").readlines() if line.strip() != ""]

sum = 0
for line in lines:
  buffer = ""
  for c in line:
    if c in "0123456789":
      buffer += c
  sum += int(buffer[0] + buffer[len(buffer)-1])

print("Part one", sum)

sum = 0
for i, line in enumerate(lines):
  found = []
  
  for i in range(len(line)):
    if line[i] in "0123456789":
      found.append(line[i])
    else:
      for j, k in enumerate(["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]):
        if i+len(k) <= len(line) and line[i:i+len(k)] == k:
          found.append(str(j))
  sum += int(found[0] + found[len(found)-1])

print("Part two", sum)

