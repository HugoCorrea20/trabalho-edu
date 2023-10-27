using UnityEngine;

public class RotacaoComMouse : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f;
    public float limiteSuperior = 80.0f;
    public float limiteInferior = -80.0f;

    private float rotaçãoVertical = 0;

    void Update()
    {
        // Captura a entrada do mouse
        float rotacaoHorizontal = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        rotaçãoVertical -= Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rotaçãoVertical = Mathf.Clamp(rotaçãoVertical, limiteInferior, limiteSuperior);

        // Aplica a rotação ao personagem
        transform.Rotate(0, rotacaoHorizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotaçãoVertical, 0, 0);
    }
}
