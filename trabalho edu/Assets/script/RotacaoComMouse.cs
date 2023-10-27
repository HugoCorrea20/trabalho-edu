using UnityEngine;

public class RotacaoComMouse : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f;
    public float limiteSuperior = 80.0f;
    public float limiteInferior = -80.0f;

    private float rota��oVertical = 0;

    void Update()
    {
        // Captura a entrada do mouse
        float rotacaoHorizontal = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        rota��oVertical -= Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rota��oVertical = Mathf.Clamp(rota��oVertical, limiteInferior, limiteSuperior);

        // Aplica a rota��o ao personagem
        transform.Rotate(0, rotacaoHorizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rota��oVertical, 0, 0);
    }
}
