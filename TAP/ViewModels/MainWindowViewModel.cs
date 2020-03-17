using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;
using TAP.Views;

namespace TAP.ViewModels
{
    public class MainWindowViewModel
    {
        public ReactiveCommand SimpleTAP { get; private set; } = new ReactiveCommand();

        public ReactiveCommand Await { get; private set; } = new ReactiveCommand();

        public ReactiveCommand DeadLock { get; private set; } = new ReactiveCommand();

        public MainWindowViewModel()
        {
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            SimpleTAP.Subscribe(_ => SimpleTAPCommand());
            Await.Subscribe(_ => AwaitCommand());
            DeadLock.Subscribe(_ => DeadLockCommand());
        }

        private void SimpleTAPCommand()
            => new SimpleTAP().ShowDialog();

        private void AwaitCommand()
            => new Await().ShowDialog();

        private void DeadLockCommand()
            => new DeadLock().ShowDialog();
    }
}
