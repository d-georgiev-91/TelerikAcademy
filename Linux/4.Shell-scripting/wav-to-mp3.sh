#!/bin/sh 
# name of this script: wav-to-mp3.sh
# wav to mp3 
# 4. Write a bash script that will convert a directory containing 
# .wav files into .mp3. Hint: use lame or menconder for the encoding.
# You can pass up to two arguments first 
# is the containing directory, the second is the target directory.
for wavFile in $1*.wav; do
	if [ -e "$wavFile" ]; then
		mp3File=`basename "$wavFile" .wav` 
		lame "$wavFile" "$2$mp3File.mp3" 
	fi 
done