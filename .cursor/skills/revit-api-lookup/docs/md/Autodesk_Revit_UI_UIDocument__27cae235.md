---
kind: type
id: T:Autodesk.Revit.UI.UIDocument
source: html/295b48c8-0571-ad5c-eead-baea84a6787c.htm
---
# Autodesk.Revit.UI.UIDocument

An object that represents an Autodesk Revit project opened in the Revit user interface.

## Syntax (C#)
```csharp
public class UIDocument : IDisposable
```

## Remarks
This class represents a document opened in the user interface and therefore offers interfaces
 to work with settings and operations in the UI (for example, the active selection). Revit can have multiple
 projects open and multiple views to those projects. The active or top most view will be the
 active project and hence the active document which is available from the UIApplication object. 
 Obtain the database level Document (which contains interfaces not related to the UI) via the
 Document property. If you have a database level Document and need to access it from the UI, you can
 construct a new UIDocument from that object (the document must be open and visible in the UI to allow the methods to
 work successfully).

