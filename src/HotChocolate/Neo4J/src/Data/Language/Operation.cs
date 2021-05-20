using System.Collections.Generic;
using System.Linq;

namespace HotChocolate.Data.Neo4J.Language
{
    /// <summary>
    /// A binary operation.
    /// </summary>
    public class Operation : Expression
    {
        private readonly Expression _left;
        private readonly Operator _op;
        private readonly Visitable _right;

        private static readonly IReadOnlyList<Operator> _labelOperators =
            new []{ Operator.SetLabel, Operator.RemoveLabel };

        private static readonly IReadOnlyList<Operator> _dontGroup =
            new [] { Operator.Exponent, Operator.Pipe };

        private static readonly IReadOnlyList<OperatorType> _needsGroupingByType =
            new [] { OperatorType.Property, OperatorType.Label };

        public Operation(Expression left, Operator op, Expression right)
        {
            _left = left;
            _op = op;
            _right = right;
        }

        public Operation(Expression left, Operator op, NodeLabels right)
        {
            _left = left;
            _op = op;
            _right = right;
        }

        public override ClauseKind Kind => ClauseKind.Operation;

        public bool NeedsGrouping() =>
            _needsGroupingByType.Contains(_op.Type) && !_dontGroup.Contains(_op);

        public override void Visit(CypherVisitor cypherVisitor)
        {
            cypherVisitor.Enter(this);
            Expressions.NameOrExpression(_left).Visit(cypherVisitor);
            _op.Visit(cypherVisitor);
            _right.Visit(cypherVisitor);
            cypherVisitor.Leave(this);
        }

        public static Operation Create(Expression op1, Operator op, Expression op2)
        {
            Ensure.IsNotNull(op1, "The first operand must not be null.");
            Ensure.IsNotNull(op, "Operator must not be empty.");
            Ensure.IsNotNull(op2, "The second operand must not be null.");

            return new Operation(op1, op, op2);
        }

        public static Operation Create(Expression op1, Operator op, params string[] nodeLabels)
        {
            Ensure.IsNotNull(op1, "The first operand must not be null.");
            Ensure.IsTrue(_labelOperators.Contains(op),
                "Only operators can be used to modify labels.");
            Ensure.IsNotEmpty(nodeLabels, "The labels cannot be empty.");

            return new Operation(
                op1,
                op,
                new NodeLabels(nodeLabels.Select(x => new NodeLabel(x)).ToList()));
        }
    }
}
