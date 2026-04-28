---
kind: method
id: M:Autodesk.Revit.UI.IDockablePaneProvider.SetupDockablePane(Autodesk.Revit.UI.DockablePaneProviderData)
source: html/c0b6c6b7-6827-a788-1f19-e02ed3423db9.htm
---
# Autodesk.Revit.UI.IDockablePaneProvider.SetupDockablePane Method

Method called during initialization of the user interface to gather information about a dockable pane window.

## Syntax (C#)
```csharp
void SetupDockablePane(
	DockablePaneProviderData data
)
```

## Parameters
- **data** (`Autodesk.Revit.UI.DockablePaneProviderData`) - Container for information about the new dockable pane. Implementers should set the 
 FrameworkElement and InitialState Properties. Optionally, providers can set the 
 ContextualHelp property if they wish to provide or react to help requests on the pane,
 or override the default EditorInteraction property by setting it here.

