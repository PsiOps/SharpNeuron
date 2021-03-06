﻿using SharpNeuron.Initializers;
using System;

namespace SharpNeuron.Backpropagation
{
    /// <summary>
    /// An <see cref="ActivationLayer"/> using logarithmic activation function
    /// </summary>
    public class LogarithmLayer : ActivationLayer
    {
        /// <summary>
        /// Constructs a new LogarithmLayer containing specified number of neurons
        /// </summary>
        /// <param name="neuronCount">
        /// The number of neurons
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <c>neuronCount</c> is zero or negative
        /// </exception>
        public LogarithmLayer(int neuronCount)
            : base(neuronCount)
        {
            initializer = new NguyenWidrowFunction();
        }

        /// <summary>
        /// Logarithmic activation function
        /// </summary>
        /// <param name="input">
        /// Current input to the neuron
        /// </param>
        /// <param name="previousOutput">
        /// The previous output at the neuron
        /// </param>
        /// <returns>
        /// The activated value
        /// </returns>
        public override double Activate(double input, double previousOutput)
        {
            return (input > 0) ? Math.Log(1 + input) : -Math.Log(1 - input);
        }

        /// <summary>
        /// Derivative of logarithmic function
        /// </summary>
        /// <param name="input">
        /// Current input to the neuron
        /// </param>
        /// <param name="output">
        /// Current output (activated) at the neuron
        /// </param>
        /// <returns>
        /// The result of derivative of activation function
        /// </returns>
        public override double Derivative(double input, double output)
        {
            return 1d / (1 + Math.Abs(input));
        }
    }
}