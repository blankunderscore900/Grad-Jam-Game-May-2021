using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maybe {
    public abstract class Maybe<T> {
        public abstract T GetValue(T default_value);
        public abstract void WithValue(Action<T> func);
        public abstract Maybe<R> WithValue<R>(Func<T, R> func);
    }

    public sealed class Just<T> : Maybe<T> {
        private readonly T value;
        public Just(T _value) {
            value = _value;
        }

        public override T GetValue(T default_value) {
            return value;
        }

        public override void WithValue(Action<T> func) {
            func(value);
        }

        public override Maybe<R> WithValue<R>(Func<T, R> func) {
            return new Just<R>(func(value));
        }
    }

    public sealed class Nothing<T> : Maybe<T> {
        public override T GetValue(T default_value) {
            return default_value;
        }

        public override void WithValue(Action<T> func) {
            // Does Nothing
        }

        public override Maybe<R> WithValue<R>(Func<T, R> func) {
            return new Nothing<R>();
        }
    }
}