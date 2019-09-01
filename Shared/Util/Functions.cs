﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ParseTreeVisualizer.Util {
    public static class Functions {
        private static string ParseCallerMemberName(string callerMemberName) {
            var s = callerMemberName;
            if (s.EndsWith("Property")) { s = s.Substring(0, s.Length - "Property".Length); }
            return s;
        }
        public static DependencyProperty DPRegister<TProperty, TOwner>(TProperty defaultValue = default, PropertyChangedCallback callback = null, [CallerMemberName] string propertyName = null) =>
            DependencyProperty.Register(ParseCallerMemberName(propertyName), typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue, callback));
        public static DependencyProperty DPRegister<TProperty, TOwner>(TProperty defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback callback = null, [CallerMemberName] string propertyName = null) =>
            DependencyProperty.Register(ParseCallerMemberName(propertyName), typeof(TProperty), typeof(TOwner), new FrameworkPropertyMetadata(defaultValue, flags, callback));

        public static DependencyProperty DPRegisterAttached<TProperty, TOwner>(TProperty defaultValue = default, PropertyChangedCallback callback = null, [CallerMemberName] string propertyName = null) =>
            DependencyProperty.RegisterAttached(ParseCallerMemberName(propertyName), typeof(TProperty), typeof(TOwner), new PropertyMetadata(defaultValue, callback));
        public static DependencyProperty DPRegisterAttached<TProperty, TOwner>(TProperty defaultValue, FrameworkPropertyMetadataOptions flags, PropertyChangedCallback callback = null, [CallerMemberName] string propertyName = null) =>
            DependencyProperty.RegisterAttached(ParseCallerMemberName(propertyName), typeof(TProperty), typeof(TOwner), new FrameworkPropertyMetadata(defaultValue, flags, callback));
        public static DependencyProperty DPRegisterAttached<TProperty, TOwner>(FrameworkPropertyMetadataOptions flags, PropertyChangedCallback callback = null, [CallerMemberName] string propertyName = null) =>
            DependencyProperty.RegisterAttached(ParseCallerMemberName(propertyName), typeof(TProperty), typeof(TOwner), new FrameworkPropertyMetadata(DependencyProperty.UnsetValue, flags, callback));

        public static KeyValuePair<TKey, TValue> KVP<TKey, TValue>(TKey key, TValue value) => new KeyValuePair<TKey, TValue>(key, value);
    }
}