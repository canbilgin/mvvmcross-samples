using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace CubiSoft.Samples.Mvvm.Client.Core.Common
{
    public class CommandableList<T> : ObservableCollection<CommandableItem<T>>
    {
    }

    public class CommandableItem<T>
    {
        private T m_Item;

        private readonly Dictionary<string, Action<T>> m_Actions;

        private Dictionary<string, MvxCommand> m_Commands;

        /// <summary>
        /// Used to expose parent commands on the item itself
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="T"/></param>
        /// <param name="actions">Dictionary of actions to be exposed as Commadns</param>
        public CommandableItem(T item, Dictionary<string, Action<T>> actions)
        {
            m_Item = item;

            if (actions != null && actions.Count > 0)
            {
                m_Actions = actions;

                m_Commands = m_Actions.ToDictionary(
                    (pair) => pair.Key,
                    (pair) => new MvxCommand(() => pair.Value(item)));
            }
        }

        private CommandableItem(T item)
        {
            m_Item = item;
        }

        public T Item
        {
            get
            {
                return m_Item;
            }
        }

        public Dictionary<string, MvxCommand> Commands
        {
            get
            {
                return m_Commands;
            }
        }

        #region IEquatable Implementation

        /// <summary>
        /// Superficial comparision, implemented to compare items of type <typeparamref name="T"/> and Commandable&lt;T&gt;
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CommandableItem<T> other)
        {
            return Item.Equals(other.Item);
        }

        #endregion

        /// <summary>
        /// Implicit Cast between Commandable&lt;T&gt;
        /// </summary>
        /// <remarks>This cast is very superficial, only used for comparison</remarks>
        /// <param name="item">Item to cast as CommandableItem</param>
        /// <returns></returns>
        public static implicit operator CommandableItem<T>(T item)
        {
            return new CommandableItem<T>(item);
        }
    }

    public static class CommandableExtensions
    {
        public static CommandableList<T> ToCommandableList<T>(this IEnumerable<T> list, Dictionary<string, Action<T>> commands)
        {
            // TODO: check for nulls;
            var newCollection = new CommandableList<T>();

            foreach (var item in list)
            {
                newCollection.Add(new CommandableItem<T>(item, commands));
            }

            return newCollection;
        }
    }
}
