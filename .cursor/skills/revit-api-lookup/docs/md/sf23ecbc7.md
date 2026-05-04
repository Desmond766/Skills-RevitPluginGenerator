---
kind: type
id: T:Autodesk.Revit.UI.SelectionUIOptions
source: html/a87989f8-c37e-e5c6-7836-ff5014a66513.htm
---
# Autodesk.Revit.UI.SelectionUIOptions

Provides access to user settings related to how selection will behave in Revit's UI.

## Syntax (C#)
```csharp
public class SelectionUIOptions : IDisposable
```

## Remarks
The settings in this class define how selection will behave when the user is
 selecting one or more elements in a graphical view. These settings do not affect programmatic selection behavior.
 Some UI commands may override the user's settings while the command is active.
 These settings are per user and will affect the selection behavior in all
 projects and families. The settings are not stored in the project.

