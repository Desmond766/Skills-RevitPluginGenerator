---
kind: property
id: P:Autodesk.Revit.UI.UIDocument.ActiveView
source: html/b6adb74b-39af-9213-c37b-f54db76b75a3.htm
---
# Autodesk.Revit.UI.UIDocument.ActiveView Property

The currently active view of the currently active document.

## Syntax (C#)
```csharp
public View ActiveView { get; set; }
```

## Remarks
This property is applicable to the currently active document only.
 Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if this document doesn't represent the active document. The active view can only be changed when:
 There is no open transaction. IsModifiable is false. IsReadOnly is false. ViewActivating, ViewActivated, and any pre-action of events (such as DocumentSaving or DocumentClosingevents) are not being handled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting the property: If the 'view' argument is NULL.
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting the property:
 If the given view is not a valid view of the document; -or- If the given view is a template view; -or- If the given view is an internal view.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting the property:
 If the document is not currently active; -or- If the document is currently modifiable (i.e. with an active transaction); -or- If the document is currently in read-only state; -or- When invoked during either ViewActivating or ViewActivated event; -or- When invoked during any pre-action kind of event, such as DocumentSaving, DocumentClosing, etc.

