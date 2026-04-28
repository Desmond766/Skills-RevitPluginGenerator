---
kind: property
id: P:Autodesk.Revit.UI.EditorInteraction.InteractionType
source: html/d95d696b-41b2-0159-0e39-fc0ab2703dbc.htm
---
# Autodesk.Revit.UI.EditorInteraction.InteractionType Property

The type of interaction.

## Syntax (C#)
```csharp
public virtual EditorInteractionType InteractionType { get; set; }
```

## Remarks
This property is overridable to allow for clients to
 dynamically return the type. For example, if your pane
 interacts with certain editors or has different "modes"
 based on user workflow.

