#!/bin/bash

for dir in ./*/
do
    cd "$dir"

    seq_number=$(basename "$dir" | cut -d '.' -f 2)

    ffmpeg -r 10 -i step%d.camera.png -c:v libx264 -vf "fps=30,format=yuv420p" out$seq_number.mp4
    cd ..
done