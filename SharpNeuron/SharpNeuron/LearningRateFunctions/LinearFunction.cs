﻿namespace SharpNeuron.LearningRateFunctions
{
    /// <summary>
    /// Linear Learning Rate Function. As the training progresses, the learning rate uniformly
    /// changes from its initial value to the final value.
    /// </summary>

    public sealed class LinearFunction : AbstractFunction
    {
        /// <summary>
        /// Constructs a new instance with the specified initial and final values of learning rate.
        /// </summary>
        /// <param name="initialLearningRate">
        /// Initial value learning rate
        /// </param>
        /// <param name="finalLearningRate">
        /// Final value learning rate
        /// </param>
        public LinearFunction(double initialLearningRate, double finalLearningRate)
            : base(initialLearningRate, finalLearningRate)
        {
        }

        /// <summary>
        /// Gets effective learning rate for current training iteration. (As the training progresses,
        /// the learning rate uniformly changes from its initial value to the final value)
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <returns>
        /// The effective learning rate for current training iteration
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public override double GetLearningRate(int currentIteration, int trainingEpochs)
        {
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            Helper.ValidateWithinRange(currentIteration, 0, trainingEpochs - 1, "currentIteration");

            return initialLearningRate + (finalLearningRate - initialLearningRate) * currentIteration / trainingEpochs;
        }
    }
}