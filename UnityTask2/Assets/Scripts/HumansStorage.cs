// Copyright (c) 2012-2025 FuryLion Group. All Rights Reserved.

using System.Collections.Generic;
using Core.Data;

namespace Core
{
    public static class HumansStorage
    {
        private static List<Human> _humans = new();

        public static int Count => _humans.Count;

        public static List<Human> GetHumans()
        {
            return _humans;
        }

        public static void AddHuman(Human human)
        {
            _humans.Add(human);
        }

        public static void EditHuman(Human human, string oldName)
        {
            _humans.Find(x => x.Name == oldName).Update(human);
        }

        public static void RemoveHuman(string name)
        {
            _humans.Remove(_humans.Find(x => x.Name == name));
        }
    }
}