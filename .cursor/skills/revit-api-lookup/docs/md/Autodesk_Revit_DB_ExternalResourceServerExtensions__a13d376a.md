---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceServerExtensions
source: html/98626c59-db02-300a-d9ef-07bcb63e8101.htm
---
# Autodesk.Revit.DB.ExternalResourceServerExtensions

An object that contains overrides for external resource-specific methods.

## Syntax (C#)
```csharp
public class ExternalResourceServerExtensions : IDisposable
```

## Remarks
This class permits assignment of some specific operations related to a type of
 external resource, such as what to do when "Open (and Unload)" happens, or when
 "Shared Coordinates update" happens for Revit or CAD links. There is no feedback to the UI server for ExternalResourceServerExtensions.
 Revit will use standard, common message dialogs to handle any error conditions.

