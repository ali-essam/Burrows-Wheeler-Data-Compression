# Burrows-Wheeler Data Compression Algorithm

This revolutionary algorithm out-compresses gzip and PKZIP, is relatively easy to implement, and is not protected by any patents. It forms the basis of the Unix compression utililty bzip2. The Burrows-Wheeler compression algorithm consists of three different algorithmic components, which are applied in succession:

1. **Burrows-Wheeler transform**: Given a normal file, transform it into a file in which series of the same byte occur near each other many times.
2. **Move-to-front encoding**: Given a file in which series of the same byte occur near each other many times, convert it into a file in which small integers appear more frequently than large ones.
3. **Huffman encoding**: Given a file in which certain symbols appear more frequently than others, compress it by encoding common bytes with short codewords and rare bytes with long codewords.

The only step that compresses the file is the final step. It is particularly effective because the first two steps result in a file in which certain bytes appear more frequently than others. To decode a message, apply the inverse operations in reverse order: first apply the Huffman decoding, then the move-to-front decoding, and finally the inverse Burrows-Wheeler transform. <sup>[1]</sup>

### About
This project is held as a part of algorithms coursework in FCIS.

Team members:
- Ali Essam
- Ahmed Ameen
- Mohamed Salama

### References
- http://www.cs.princeton.edu/courses/archive/spr03/cs226/assignments/burrows.html [1]
- http://michael.dipperstein.com/bwt/