---
kind: property
id: P:Autodesk.Revit.UI.RibbonButton.IsEnabledByContext
source: html/f4b64459-2b49-441d-3690-d86dd179a641.htm
---
# Autodesk.Revit.UI.RibbonButton.IsEnabledByContext Property

Indicates if this button can be executed. True if the pushbutton is permitted to be executed based on the 
current Revit context (active document, active view and active tool). False if the pushbutton is disabled because 
of the active context.

## Syntax (C#)
```csharp
public bool IsEnabledByContext { get; }
```

## Remarks
The button may be enabled for a given context but still disabled programmatically using the Enabled property
for the button.

