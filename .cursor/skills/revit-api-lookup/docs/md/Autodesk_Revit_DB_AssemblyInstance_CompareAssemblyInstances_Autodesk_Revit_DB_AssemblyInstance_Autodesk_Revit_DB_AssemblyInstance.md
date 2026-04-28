---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.CompareAssemblyInstances(Autodesk.Revit.DB.AssemblyInstance,Autodesk.Revit.DB.AssemblyInstance)
source: html/d7253e56-f112-45d0-8b59-f6cb86b42159.htm
---
# Autodesk.Revit.DB.AssemblyInstance.CompareAssemblyInstances Method

Compares two assembly instances and returns a result with details about the differences

## Syntax (C#)
```csharp
public static AssemblyDifference CompareAssemblyInstances(
	AssemblyInstance instance1,
	AssemblyInstance instance2
)
```

## Parameters
- **instance1** (`Autodesk.Revit.DB.AssemblyInstance`) - The first assembly instance to compare
- **instance2** (`Autodesk.Revit.DB.AssemblyInstance`) - the second assembly instance to compare

## Returns
An object describing the difference between the two instances

## Remarks
Only the first found difference is returned.
 If the instances are identical, AssemblyDifferenceNone will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

