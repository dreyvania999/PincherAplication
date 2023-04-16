﻿
namespace PincherApp
{
    internal class SalesInformation : IManagers
    {
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                }
            }
        }
    }
}