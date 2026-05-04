---
kind: type
id: T:Autodesk.Revit.DB.TessellatedShapeBuilder
source: html/a144b0e3-c997-eac1-5c00-51c56d9e66f2.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder

A class that permits structured building of geometry or
 a mesh from a collection of connected faces.
 Contains all closed face sets and custom precisions.

## Syntax (C#)
```csharp
public class TessellatedShapeBuilder : ShapeBuilder
```

## Remarks
Creates a geometry populated with faces defined by TessellatedFace objects
 stored in the input connected face sets.
 The faces defined by each connected face set may form an open shell or
 the boundary of a solid 3D region.
 All faces are planar and have polyline boundaries, defined
 as sequences of 3d coordinates.
 Faces are added to the builder as a part of connected face sets,
 representing faces which share edges.
 Order of faces in the sets is irrelevant. Faces can only
 be added to the builder when a face set has been opened and is available
 to take in faces (use OpenConnectedFaceSet(Boolean) to open a new face set).
 Before attempting to build Revit geometry from the builder
 the current face set should be closed
 ( CloseConnectedFaceSet () () () ).
 The builder allows for the possibility of multiple face sets.
 The builder will try to create a geometry valid in Revit despite
 inconsistencies or omissions in the input data.
 For each connected face set, it will check the face orientations and
 change them wherever needed so that the orientations of the faces
 in that set are consistent. If a connected face set is closed, it will check if the face normals
 point outward. If not, it will reverse the orientations of all faces.
 That means, each closed connected face set will represent a solid. 
 Limitations in the current implementation:
 It does not support the definition of a "void", even if the user had
 set the orientations of the faces to define a "void". If there is more than one connected face set, it does not check if they
 intersect or overlap each other.

