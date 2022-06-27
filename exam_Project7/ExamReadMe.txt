My student number is 201809330, so my project number is 30 mod 23 = 7.

Project number 7 was the "Symmetric rank-1 update of a size-n symmetric eigenvalue problem".
The matrix of interest, \textbf{A}, is a $n\cross n$ matrix constructed from the sum of a diagonal matrix \textbf{D}, with elements ${d_1,...,d_n}$ and the outer product of a vector \textbf{u} of n random elements with itself multiplied by a factor $\sigma$.

Finding roots of the scalar secular equation given in the eigenvalues chapter of the book (eq. 21),
$$1+\sum_{i=1}^m{\frac{\sigma u^2_i}{d_i - \lambda}} = 0$$,
gives us the n values of $\lambda$ corresponding to the eigenvalues of \textbf{A}. The Newton-Raphson method is used for this.

The Jacobi eigenvalue algorithm implemented in the Eigenvalues homework is used to check the found eigenvalues' validity.

After the code has been shown to work, we run through values of n from 2 to 200, plotting the time taken for each value of n. These values are plotted with a n^2 polynomial fit to see whether we fulfill the O(n^2) requirement.
The same is done with the Jacobi algorithm to compare times.
This part take about 30 seconds in total to run.