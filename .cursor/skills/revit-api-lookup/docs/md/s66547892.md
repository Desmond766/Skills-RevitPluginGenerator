---
kind: type
id: T:Autodesk.Revit.DB.TemporaryViewModes
source: html/cf6ecc84-e459-55c5-a4d7-d88ae4033a23.htm
---
# Autodesk.Revit.DB.TemporaryViewModes

A data structure containing data related to temporary view modes.

## Syntax (C#)
```csharp
public class TemporaryViewModes : APIObject
```

## Remarks
The class contains methods and properties to manipulate states
 of various temporary view modes that may or may not be avilable
 in any of visible views of a Revit document. The temporary modes are
 enumerated in the TemporaryViewMode 
 class. Every view that supports temporary view modes owns an instance
 of this TemporaryViewModes class, which can be obtained by
 accessing the TemporaryViewModes 
 property of the View class.
 Note that views which do not support temporary modes will have that
 property's value be Null. Multiple temporary view modes can coexist.
 Also, TemporaryViewProperties mode can be customized to display custom title and custom color.
 Setting custom title and color affects only TemporaryViewProperties mode for the specific view.
 CustomTitle CustomColor IsCustomized () () () RemoveCustomization () () ()

