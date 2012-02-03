using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GildedRose.Console.AnotherSetOfItems
{
    public static class ReflectionExtensions
    {
        public static void SetPropertyValue<InputType, PropertyType>(this Expression<Func<InputType, PropertyType>> expression, InputType input, PropertyType valueToSet)
        {
            ((PropertyInfo)((MemberExpression)expression.Body).Member).SetValue(input, valueToSet, null);
        }
    }
}