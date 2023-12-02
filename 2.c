#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    FILE* f = fopen("./input.txt", "r");
    if (f == NULL)
        return 1;

    char line[256];
    int iter = 1;
    int part_one_sum = 0;
    int part_two_sum = 0;

    while (fgets(line, sizeof(line), f) != NULL) {
        line[strlen(line) - 1] = 0; // discard \n
        int r, g, b, bR, bG, bB; // bR, bG = biggest r, biggest g...
        r = g = b = bR = bG = bB = 0;
        int valid_game = 1;

        for (int i = 0; i < strlen(line); i++) {
            if (line[i] == ';' || i == strlen(line) - 1) { // if new set started or line is over
                if (!(r <= 12 && g <= 13 && b <= 14)) {
                    valid_game = 0;
                }

                if (r > bR)
                    bR = r;

                if (g > bG)
                    bG = g;

                if (b > bB)
                    bB = b;

                r = g = b = 0;
            }

            if (i != 5 && line[i-1] == ' ') { // not id num and also prev char was not int
                char num[3] = {0};
                char col;

                if ((int)line[i] > 48 && (int)line[i] < 58) { // char is an integer
                    num[0] = line[i];
                    col = line[i+2];

                    if ((int)line[i+1] > 47 && (int)line[i+1] < 58) { // if char after that is an integer
                        num[1] = line[i+1];
                        col = line[i+3];
                    }

                    int num_int = atoi(num);

                    switch (col) {
                    case 'r':
                        r += num_int;
                        break;
                    case 'g':
                        g += num_int;
                        break;
                    case 'b':
                        b += num_int;
                        break;
                    }
                }
            }
        }

        part_two_sum += (bR * bG * bB);

        if (valid_game) 
            part_one_sum += iter;

        iter++;
    }

    printf("Part one: %d\n", part_one_sum);
    printf("Part two: %d\n", part_two_sum);

    fclose(f);

    return 0;
}
