---
kind: type
id: T:Autodesk.Revit.DB.TemporaryGraphicsManager
source: html/1dd29f70-d381-fa60-8ffa-1076eac55ed7.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager

A class that provides functionality to create temporary graphics in a Revit model.

## Syntax (C#)
```csharp
public class TemporaryGraphicsManager : IDisposable
```

## Remarks
The graphics created by this class are temporary or transient. They are not subject to undo and are not saved. It's caller's
 responsiblity to manage their lifetime, creation and destruction, though Revit will destroy all of them when closing the model.

