﻿using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModel
{
    /// <summary>     
    /// This class contains static references to all the view models in the     
    /// application and provides an entry point for the bindings.     
    /// <para>     
    /// See http://www.mvvmlight.net    
    /// </para>     
    /// </summary>     
    public class ViewModelLocator
    {

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();
        }

        /// <summary>         
        /// Gets the Main property.  
        /// </summary>         
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SecondViewModel Second => ServiceLocator.Current.GetInstance<SecondViewModel>();
    } 
} 