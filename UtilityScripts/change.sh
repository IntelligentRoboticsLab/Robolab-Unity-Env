#!/bin/bash

# Loop through every text file in the current directory
for file in *.txt; do
    # Check if the first character of the file is a 1
    first_char=$(head -c 1 "$file")
    if [ "$first_char" = "1" ]; then
        # Replace the first character with a 0
        sed -i '1s/^1/0/' "$file"
        echo "Replaced 1 with 0 in $file"
    else
        echo "Did not find 1 at beginning of $file"
    fi
done