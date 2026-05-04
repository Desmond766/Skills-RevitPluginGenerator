---
kind: type
id: T:Autodesk.Revit.DB.WorksetConfiguration
source: html/eefef6f4-0892-4bb5-8840-5e99aebc65c9.htm
---
# Autodesk.Revit.DB.WorksetConfiguration

A configuration class that is passed in to methods that open Revit documents to specify which user-created worksets are opened/closed.

## Syntax (C#)
```csharp
public class WorksetConfiguration : IDisposable
```

## Remarks
Once an instance of this class is created, it can be further modified
 by calling any of the other methods in any order. It is a specification of a setting for model open;
 the methods of this class just adjust the specification, and do not themselves open or close worksets. Only user-created worksets can be specified to be opened or closed. All system worksets are automatically open.
 An open workset allows its elements can be expanded and displayed.
 For a closed workset, Revit tries to not expand its elements, and to that end, does not display them.
 This is intended to help with performance by reducing Revit's memory footprint.

