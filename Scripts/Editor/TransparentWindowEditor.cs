using UnityEditor;
using UnityEngine;

public class TransparentWindowEditor : MonoBehaviour
{
  [MenuItem("GameObject/Transparent Window", false, 30)]
  public static void CreateObject(MenuCommand menuCommand)
  {
    GameObject separator = new GameObject("Transparent Window");
    separator.AddComponent<TransparentWindow>();
    GameObjectUtility.SetParentAndAlign(separator, menuCommand.context as GameObject);
    Undo.RegisterCreatedObjectUndo(separator, "Create " + separator.name);
    Selection.activeObject = separator;
  }
}