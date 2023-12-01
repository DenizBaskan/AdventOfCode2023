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
      for k in (nums := {
        "one": "1",
        "two": "2",
        "three": "3",
        "four": "4",
        "five": "5",
        "six": "6",
        "seven": "7",
        "eight": "8",
        "nine": "9",
        "zero": "0"
      }):
        if i+len(k) <= len(line) and line[i:i+len(k)] == k:
          found.append(nums[k])
  sum += int(found[0] + found[len(found)-1])

print("Part two", sum)
