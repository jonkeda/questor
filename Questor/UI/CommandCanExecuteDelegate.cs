﻿namespace Questor.UI
{
    public delegate bool CommandCanExecuteDelegate();

    public delegate bool CommandCanExecuteDelegate<in T>(T parameter);
}