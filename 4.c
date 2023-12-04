#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define IS_INT(x) ((int)x > 47 && (int)x < 58)
#define MAX_WINNERS_AMOUNT 10
#define MAX_LINE_LEN 256
#define MAX_CARDS_LEN 250

int main(int argc, char** argv)
{
    FILE* f = fopen("./input.txt", "r");
    if (f == NULL)
        return 1;

    char line[MAX_LINE_LEN];
    int sum = 0;

    int matches[MAX_CARDS_LEN] = {0};
    int matches_i = 0;

    while (fgets(line, sizeof(line), f) != NULL) {
        matches_i++;

        int winners[MAX_WINNERS_AMOUNT] = {0};
        int winners_i = 0;

        int winners_flag = 0;
        int numbers_flag = 0;

        int score = 0;

        for (int i = 0; i < strlen(line); i++) {
            if (line[i] == ':')
                winners_flag = 1;

            else if (line[i] == '|') {
                numbers_flag = 1;
                winners_flag = 0;
            }

            if (IS_INT(line[i]) && !IS_INT(line[i - 1])) {
                char num[3] = {0};

                if (IS_INT(line[i + 1])) {
                    num[0] = line[i];
                    num[1] = line[i + 1];
                } else {
                    num[0] = line[i];
                }

                if (numbers_flag) {
                    for (int j = 0; j < MAX_WINNERS_AMOUNT; j++) {
                        if (atoi(num) == winners[j]) {
                            if (score > 0) 
                                score = score * 2;
                            else
                                score++;
                            matches[matches_i]++;
                        }
                    }
                } else if (winners_flag) {
                    winners[winners_i] = atoi(num);
                    winners_i++;
                }
            }
        }

        sum += score;
    }

    int cards[MAX_CARDS_LEN] = {0};
    int total_cards = 0;

    for (int i = 1; i < matches_i + 1; i++) {
        cards[i]++;
        total_cards++;

        if (matches[i] == 0)
            continue;

        for (int h = 0; h < cards[i]; h++) {
            for (int j = i + 1; j < i + matches[i] + 1; j++) {
                cards[j]++;
                total_cards++;
            }
        }
    }

    printf("Part one: %d\n", sum);
    printf("Part two: %d\n", total_cards);

    return 0;
}
