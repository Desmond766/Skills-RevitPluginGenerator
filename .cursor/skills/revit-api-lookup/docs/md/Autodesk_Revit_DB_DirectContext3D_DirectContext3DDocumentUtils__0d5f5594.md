---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils
source: html/f30693d6-532f-6de8-25d9-6fd23337cb2e.htm
---
# Autodesk.Revit.DB.DirectContext3D.DirectContext3DDocumentUtils

The methods provided by this utility class support the use of DirectContext3D and storage of DirectContext3D handle elements in Revit documents.

## Syntax (C#)
```csharp
public static class DirectContext3DDocumentUtils
```

## Remarks
DirectContext3D graphics can be displayed without storing the graphics in elements. However, the reference to the externally generated
 graphics will not persist beyond the current session, and there will be no capabilities for the user to select and interact with the graphics.
 The utility methods in this class support creation and updating of DirectContext3D handle and handle instance elements (which for this release are
 [!:Autodesk::Revit::DB::DirectShapeType] and [!:Autodesk::Revit::DB::DirectShape] instances, however this may not always be the
 case). The capabilities provided by these handle elements include:
 A special geometry object remembers the existence and source location of the external graphics. A generated 3D bounding box surrounds the provided graphics. This box is set to be selectable but its properties are mostly not modifiable.
 However, the user can reposition the box and the associated external graphics with it. The type and instance relationship between DirectContext3D handles and handle instances allows one DirectContext3D server to act as the provider
 of one set of graphics (the type) that the API displays in multiple locations, as determined by the handle instances. The handle element will be associated to a specified category. The only currently valid category is OST_Coordination_Model. The application is required to update the handle type element using [!:UpdateDirectContext3DHandleType()] whenever the source data
 changes. It also is required that the application update the handle during initial load of the document containing this element.

