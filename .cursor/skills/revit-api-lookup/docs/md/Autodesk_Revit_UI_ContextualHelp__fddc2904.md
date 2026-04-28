---
kind: type
id: T:Autodesk.Revit.UI.ContextualHelp
source: html/4126f1e6-8055-a42a-166d-511c4a794a8d.htm
---
# Autodesk.Revit.UI.ContextualHelp

Contains the details for how Revit should allow invocation of contextual help for an item added by an application.

## Syntax (C#)
```csharp
public class ContextualHelp
```

## Remarks
An instance of this class may be used to assign a contextual help location to any RibbonItem (through the RibbonItem.SetContextualHelp() method).
It is also possible to use an instance of this class to launch the help path and topic at any time (this permits association of help topics with
user interface components inside dialogs created by the add-in application).

